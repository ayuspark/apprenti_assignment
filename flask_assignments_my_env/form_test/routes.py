from flask import Flask, render_template, request, redirect, session

app = Flask(__name__)
app.secret_key = '123456'


@app.route('/')
def index():
    return render_template('index.html')


@app.route('/users', methods=['POST'])
def create_user():
    print 'Got post info'
    session['name'] = request.form['name']
    session['email'] = request.form['email']
    print request.form
    return redirect('/show')


@app.route('/show')
def show():
    return render_template('user.html',
                           name=session['name'],
                           email=session['email'])


app.run(debug=True)