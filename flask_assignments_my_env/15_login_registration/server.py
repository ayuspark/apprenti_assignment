from flask import Flask, render_template, redirect, request, url_for

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


class NameForm(FlaskForm):
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


@app.route('/', methods=['GET', 'POST'])
def index():
        form = NameForm()
        print(form.fname.data)
        if form.validate_on_submit():
                query = '''
                        INSERT INTO users
                        (fname, lname, email, psw)
                        VALUES(:fname, :lname, :email, :psw)
                        '''
                data = {
                        'fname': form.fname.data,
                        'lname': form.lname.data,
                        'email': form.email.data,
                        'psw': form.psw.data,
                }
                mysql.query_db(query, data)
                return redirect(url_for('index'))
        return render_template('index.html', form=form)



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

