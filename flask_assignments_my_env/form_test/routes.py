from flask import Flask, render_template, request, redirect, session, flash
import re

app = Flask(__name__)
app.secret_key = 'realsecret'
EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')


@app.route('/')
def index():
    return render_template('index.html')


@app.route('/users', methods=['POST'])
def create_user():
    if (len(request.form['email']) < 1) or (len(request.form['name']) < 1) or (len(request.form['comment']) > 10):
        flash('YOU HAVE FIELDS MISSING!')
        return redirect('/')
    else:
        if not EMAIL_REGEX.match(request.form['email']):
            flash('INVALID EMAIL ADDRESS')
            return redirect('/')
        else:
            session['name'] = request.form['name']
            session['email'] = request.form['email']
            session['comment'] = request.form['comment']
            print request.form
            return redirect('/show')


@app.route('/show')
def show():
    return render_template('user.html',
                           name=session['name'],
                           email=session['email'],
                           comment=session['comment'])


app.run(debug=True)
