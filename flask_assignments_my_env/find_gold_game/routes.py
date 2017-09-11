from flask import Flask, render_template, request, redirect, session, url_for
import random
from datetime import datetime


app = Flask(__name__)
app.secret_key = 'realsecret'


@app.route('/')
def index():
    if 'gold_amount' not in session or 'msg' not in session:
        session['gold_amount'] = 0
        session['msg'] = []
    return render_template('index.html', 
                           gold_amount=session['gold_amount'],
                           msgs=session['msg'])


@app.route('/process', methods=['POST'])
def get_gold():
    gold_dict = {
        'farm': random.randint(10, 20),
        'cave': random.randint(5, 10),
        'house': random.randint(2, 5),
        'casino': int(round(random.uniform(-1, 1)*51)),
    }
    if request.method == 'POST':
        session['building'] = request.form.get('building')
        session['gold_amount'] += gold_dict[session['building']]
        msg = 'Entered a ' + request.form.get('building') + ' and got ' + str(gold_dict[session['building']]) + ' golds. ' + str(datetime.now())[:19]
        session['msg'].append(msg)
    return redirect(url_for('index'))


app.run(debug=True)
