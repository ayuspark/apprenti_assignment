from flask import Flask, render_template, session, request, redirect, flash
import re

app = Flask(__name__)
app.secret_key = 'realsecret'
EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')

@app.route('/', methods=['POST', 'GET'])
def index():
    return render_template('index.html', 
                           name=session['name'],
                           email=session['email'],
                           password=session['pass'])


@app.route('/form', methods=['POST'])
def handle_form():
    # if request.method == 'POST':
    if len(request.form['name']) > 0 and len(request.form['email']) > 0 and len(request.form['password']) > 0:
        if not any(char.isdigit() for char in request.form['name']):
            session['name'] = request.form['name']
        else:
            flash(u'INVALID NAME FORM!', 'error')
        if not EMAIL_REGEX.match(request.form['email']):
            flash('INVALID EMAIL ADDRESS', 'error')
        else:
            session['email'] = request.form['email']
        if len(request.form['password']) < 8:
            flash('PASSWORD MUST BE AT LEAST 8 CHARACTERS!', 'error')
        elif request.form['password'] != request.form['confirm_pass']:
            flash('PASSWORD CONFIRMATION FAILURE')
        else:
            session['pass'] = request.form['password']
        print(request.form)
        flash('SUCCESS!')
    else:
        flash('FILL IN ALL BLANKS!')
    return redirect('/')

app.run(debug=True)
