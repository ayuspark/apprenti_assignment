from flask import Flask, render_template, request, json, session, url_for

import random

app = Flask(__name__)
app.secret_key = 'realsecret'


@app.route('/')
def index():
    if 'guess_time' not in session:
        session['guess_time'] = 0
    return render_template('index.html')


@app.route('/process', methods=['POST'])
def show_num():
    session['guess_time'] += 1
    if request.method == 'POST':
        comp_guess = random.randint(1, 100)
        data_posted = request.form['guess_num']
        # data_posted = json.loads(request.data)['guess']
        print('client made the guess: ', data_posted)
        print('comp guess:', comp_guess)
        if session['guess_time'] < 10:
            if comp_guess == int(data_posted):
                response = 'Bingo'
            elif comp_guess > int(data_posted):
                response = 'Too low'
            else:
                response = 'Too high'
        else:
            response = 'Out of guesses!'
            session['guess_time'] = 0
    
    print(response)
    return response

app.run(debug=True)

