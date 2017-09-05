from flask import Flask, render_template, request, redirect, session, url_for

app = Flask(__name__)
app.secret_key = 'secret_for_realsies'


@app.route('/')
def index():
    return render_template('index.html')


@app.route('/cats')
def cats():
    display = False
    return render_template('cats.html', display=display)


@app.route('/form')
def form_page():
    return render_template('form.html')

@app.route('/form', methods=['POST'])
def form_submit():
    display = True
    session['name'] = request.form['name'] 
    session['gender'] = request.form['gender']
    session['comment'] = request.form['comment']
    return render_template('cats.html',
                           display=display,
                           name=session['name'],
                           gender=session['gender'],
                           comments=session['comment'])


app.run(debug=True)