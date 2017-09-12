from flask import Flask, render_template, redirect, request
from mysqlconnection import MySQLConnector

app = Flask(__name__)

mysql = MySQLConnector(app, 'friendsdb')

@app.route('/')
def index():
    query = 'SELECT * from friends'
    friends = mysql.query_db(query)
    return render_template('index.html', friends=friends)

@app.route('/friends', methods=['POST'])
def create():
    query = """
            INSERT INTO friends
            (first_name, last_name, occupation, created_at, updated_at)
            VALUES(:first_name, :last_name, :occupation, NOW(), NOW())
            """
    data = {
            'first_name': request.form.get('first_name'),
            'last_name': request.form.get('last_name'),
            'occupation': request.form.get('occupation'),
            }
    mysql.query_db(query, data)
    return redirect('/')

@app.route('/friends/<friend_id>')
def show(friend_id):
    query = 'SELECT * FROM friends WHERE id=:specific_id'
    data = {'specific_id': friend_id}
    friends = mysql.query_db(query, data)
    return render_template('index.html', one_friend=friends[0])

@app.route('/delete/<friend_id>', methods=['GET'])
def delete(friend_id):
    query = '''
            DELETE FROM friends
            WHERE id = :get_id
            '''
    data = {'get_id': friend_id}
    mysql.query_db(query, data)
    return redirect('/')


app.run(debug=True)

