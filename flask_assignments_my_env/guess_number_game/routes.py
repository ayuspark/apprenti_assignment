from flask import Flask, render_template, request, json, session, url_for

import random

app = Flask(__name__)
app.secret_key = 'realsecret'

@app.route('/')
def index():
    if not 'guess_time' in session:
        session['guess_time'] = 0
    return render_template('index.html')


@app.route('/', methods=['POST'])
def show_num():
    session['guess_time'] += 1
    while (session['guess_time'] < 3):
        if request.method == 'POST':
            comp_guess = random.randint(1, 100)
            data_posted = request.form['guess']
            print('client made the guess: ', data_posted)
            if comp_guess == int(data_posted):
                response = 'Bingo'
            elif comp_guess > int(data_posted):
                response = 'Too low'
            else:
                response = 'Too high'
    response = 'Out of guesses!'
    response = json.dumps(response)
    return response

app.run(debug=True)

