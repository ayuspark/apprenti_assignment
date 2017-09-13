from flask import Flask, render_template, redirect, request, url_for, flash, session

from wtforms import StringField, SubmitField, PasswordField, validators
from wtforms.validators import Required
from flask_wtf import FlaskForm

from flask_bootstrap import Bootstrap

from mysqlconnection import MySQLConnector
from datetime import datetime, date

app = Flask(__name__)
app.config['SECRET_KEY'] = 'hard to guess string'

bootstrap = Bootstrap(app)
mysql = MySQLConnector(app, 'login_registration')


class RegisterForm(FlaskForm):
        fname = StringField('First Name: ',
                            [validators.DataRequired(),
                             validators.Length(min=2, max=10),
                             validators.Regexp('^[a-zA-Z]+$')])
        lname = StringField('Last Name: ',
                            [validators.DataRequired(),
                             validators.Length(min=2, max=10),
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
        email = StringField('Email: ',
                            [validators.DataRequired(),
                            validators.Email('Invalid email')])
        psw = PasswordField('Password: ', [validators.DataRequired()])
        submit = SubmitField('Login')


@app.route('/', methods=['GET', 'POST'])
def index():
        form = RegisterForm()
        if form.validate_on_submit():
                query = "SELECT * FROM users WHERE email=:form_email"
                data = {
                        'form_email': form.email.data,
                        }
                result = mysql.query_db(query, data)
                if result:
                        flash('You have an account, please log in')
                else:
                        query = """
                                INSERT INTO users
                                (fname, lname, email, psw)
                                VALUES(:fname, :lname, :email, :psw)
                                """
                        data = {
                                'fname': form.fname.data,
                                'lname': form.lname.data,
                                'email': form.email.data,
                                'psw': form.psw.data,
                                }
                        mysql.query_db(query, data)
                        flash('Success!')
                        return redirect(url_for('index'))
        return render_template('index.html', form=form)


@app.route('/login', methods=['POST', 'GET'])
def login():
        form = LoginForm()
        if 'email' not in session:
                session.pop('_flashes')
                session['email'] = ''
        elif session['email'] != '':
                print(session['email'])
                flash('You are logged in! Your email is: %s' % (session['email']))
        if form.validate_on_submit():
                query = "SELECT id, psw, email FROM users WHERE email=:form_email"
                data = {
                        'form_email': form.email.data
                        }
                result = mysql.query_db(query, data)
                print(result)
                if result and result[0]['psw'] == form.psw.data:
                        session['email'] = form.email.data
                        print(session['email'])
                        print('email: ', result[0]['email'])
                        flash('Success!')
                else:
                        flash('Somgthing is fishy...')
        return render_template('login.html', form=form)




#     query = 'SELECT * from friends'
#     friends = mysql.query_db(query)
#     return render_template('index.html', 
#                            friends=friends,
#                            friend_since=datetime.now().date())

# @app.route('/friends', methods=['POST'])
# def create():
#     query = """
#             INSERT INTO friends
#             (first_name, last_name, occupation, created_at, updated_at)
#             VALUES(:first_name, :last_name, :occupation, :friend_since, NOW())
#             """
#     data = {
#             'first_name': request.form.get('first_name'),
#             'last_name': request.form.get('last_name'),
#             'occupation': request.form.get('occupation'),
#             'friend_since': request.form.get('friend_since')
#             }
#     mysql.query_db(query, data)
#     return redirect('/')


app.run(debug=True)

