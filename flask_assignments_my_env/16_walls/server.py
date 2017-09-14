from flask import Flask, render_template, redirect, request, url_for, flash, session

from wtforms import StringField, SubmitField, PasswordField, validators, TextAreaField
from wtforms.validators import Required
from flask_wtf import FlaskForm
from flask_wtf.csrf import CSRFProtect

from flask_bootstrap import Bootstrap

import md5
import os
import binascii

from mysqlconnection import MySQLConnector
from datetime import datetime, date


app = Flask(__name__)
app.config['SECRET_KEY'] = 'hard to guess string'

csrf = CSRFProtect(app)
csrf.init_app(app)

bootstrap = Bootstrap(app)
mysql = MySQLConnector(app, 'walls_db')


class PostForm(FlaskForm):
        msg = TextAreaField('Post a message',
                            [validators.DataRequired(),
                             validators.Length(max=140, message='max 140 characters')])
        submit = SubmitField('Post')


class CommentForm(FlaskForm):
        comment = TextAreaField('Comment',
                                [validators.DataRequired(),
                                 validators.Length(max=140, message='max 140 characters')])
        submit = SubmitField('Comment')


class RegisterForm(FlaskForm):
        #inherit from FlaskFrom to make registration form
        fname = StringField('First Name: ',
                            [validators.DataRequired(),
                             validators.Length(min=2, max=25),
                             validators.Regexp('^[a-zA-Z]+$')])
        lname = StringField('Last Name: ',
                            [validators.DataRequired(),
                             validators.Length(min=2, max=25),
                             validators.Regexp('^[a-zA-Z]+$')])
        email = StringField('Email: ',
                            [validators.DataRequired(),
                             validators.Email('Invalid email!')])
        psw = PasswordField('Password: ',
                            [validators.DataRequired(),
                             validators.Length(min=4, max=25),
                             validators.DataRequired(),
                             validators.EqualTo('psw_confirm')])
        psw_confirm = PasswordField('Confirm psw: ', 
                                    [validators.DataRequired()])
        submit = SubmitField('Submit')


class LoginForm(FlaskForm):
        #inherit from FlaskForm to make login form
        email = StringField('Email: ',
                            [validators.DataRequired(),
                            validators.Email('Invalid email')])
        psw = PasswordField('Password: ', [validators.DataRequired()])
        submit = SubmitField('Login')


@app.route('/', methods=['GET', 'POST'])
def index():
        # msg_form = PostForm()
        # comment_form = CommentForm()
        #to display all messages
        query = """SELECT CONCAT_WS(' ', users.fname, users.lname) AS name,
                messages.msg, DATE_FORMAT(messages.created_at, \"%M %D %Y %T\") AS created_at, messages.id AS msg_id, users.id AS user_id
                FROM messages
                JOIN users ON messages.user_id = users.id
                ORDER BY messages.created_at DESC
                """
        results = mysql.query_db(query)
        # print('result: ', results)
        return render_template('index.html',
                        #        msg_form=msg_form,
                        #        comment_form=comment_form,
                               results=results)

@app.route('/post', methods=['POST'])
def post_msg():
        if 'email' in session:
                if msg_form.validate_on_submit():
                        query = "INSERT INTO messages (msg, user_id, created_at, updated_at) VALUE(:form_msg, :session_user_id, NOW(), NOW())"
                        data = {
                                'form_msg': msg_form.msg.data,
                                'session_user_id': session['user_id'],
                                }
                        mysql.query_db(query, data)
                        return redirect(url_for('index'))
        else:
                flash('Please register or log in!')
                return redirect(url_for('index'))
        return render_template('msg_form.html',
                               msg_form=msg_form,
                               comment_form=comment_form,)
        

@app.route('/delete', methods=['POST', 'GET'])
@csrf.exempt
def delete_msg():
        if 'email' not in session or session['email'] == '':
                flash('Please log in or register first!')
        else:
                if request.method == 'POST':
                        if str(session['user_id']) == request.form['user_id']:
                                msg_id_to_delete = request.form['msg_id']
                                query = "DELETE FROM messages WHERE id=:msg_id"
                                data = {
                                        'msg_id': msg_id_to_delete
                                        }
                                mysql.query_db(query, data)
                                flash('Post deleted!')
                        else:
                                flash('You can only delete your own posts!')
                return redirect(url_for('index'))


@app.route('/register', methods=['GET', 'POST'])
def register():
        form = RegisterForm()
        if 'email' not in session:
                session['email'] = ''
                session['user_id'] = 0
        if form.validate_on_submit():
                query = "SELECT * FROM users WHERE email=:form_email"
                data = {
                        'form_email': form.email.data,
                        }
                result = mysql.query_db(query, data)
                if result:
                        flash('You have an account, please log in')
                else:
                        form_pwd = form.psw.data
                        salt = binascii.b2a_hex(os.urandom(15))
                        hashed_pwd = md5.new(form_pwd + salt).hexdigest()
                        query = """
                                INSERT INTO users
                                (fname, lname, email, psw, salt, created_at, updated_at)
                                VALUES(:fname, :lname, :email, :psw, :salt, NOW(), NOW())
                                """
                        data = {
                                'fname': form.fname.data,
                                'lname': form.lname.data,
                                'email': form.email.data,
                                'psw': hashed_pwd,
                                'salt': salt,
                                }
                        mysql.query_db(query, data)
                        flash('Success!')
                #automatic log in after registration
                query = "SELECT id FROM users WHERE email=:form_email"
                data = {
                        'form_email': form.email.data,
                        }
                result = mysql.query_db(query, data)
                session['email'] = form.email.data
                session['user_id'] = result[0]['id']
                return redirect(url_for('index'))
        return render_template('register.html', form=form)


@app.route('/login', methods=['POST', 'GET'])
def login():
        form = LoginForm()
        if 'email' not in session:
                session['email'] = ''
                session['user_id'] = 0
        elif session['email'] != '':
                print('session: ', session['email'])
                flash('You are logged in! Your email is: %s' % (session['email']))
        if form.validate_on_submit():
                query = "SELECT * FROM users WHERE email=:form_email"
                data = {
                        'form_email': form.email.data
                        }
                result = mysql.query_db(query, data)
                print(result)
                if result:
                        form_pwd = form.psw.data
                        salt = result[0]['salt']
                        hashed_pwd = md5.new(form_pwd + salt).hexdigest()
                        if result[0]['psw'] == hashed_pwd:
                                session['email'] = form.email.data
                                session['user_id'] = result[0]['id']
                                print(session['email'])
                                print('email: ', result[0]['email'])
                                flash('Success!')
                        else:
                                flash('Somgthing is fishy...')
                else:
                        flash("Your account doesn't exist!")
        return render_template('login.html', form=form)


app.run(debug=True)

