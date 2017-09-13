from flask import Flask, render_template, request, json, session

app = Flask(__name__)
app.secret_key = 'realsecret'


@app.route('/')
def index():
    if 'counts' not in session:
        session['counts'] = 0
    else:
        session['counts'] += 1
    print('this is session' + str(session['counts']))
    return render_template('index.html', counts=session['counts'])


@app.route('/reload')
def reload_page():
    session['counts'] += 2
    print('reload button clicked' + str(session['counts']))
    return render_template('index.html', counts=session['counts'])


app.run(debug=True)
