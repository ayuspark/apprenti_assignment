from flask import Flask, render_template, redirect, request
from mysqlconnection import MySQLConnector
from datetime import datetime, date

app = Flask(__name__)

mysql = MySQLConnector(app, 'friendsdb')

@app.route('/')
def index():
    query = 'SELECT * from friends'
    friends = mysql.query_db(query)
    return render_template('index.html', 
                           friends=friends,
                           friend_since=datetime.now().date())

@app.route('/friends', methods=['POST'])
def create():
    query = """
            INSERT INTO friends
            (first_name, last_name, occupation, created_at, updated_at)
            VALUES(:first_name, :last_name, :occupation, :friend_since, NOW())
            """
    data = {
            'first_name': request.form.get('first_name'),
            'last_name': request.form.get('last_name'),
            'occupation': request.form.get('occupation'),
            'friend_since': request.form.get('friend_since')
            }
    mysql.query_db(query, data)
    return redirect('/')


app.run(debug=True)

