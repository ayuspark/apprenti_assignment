from flask import Flask, render_template, request, redirect, session

app = Flask(__name__)
app.secret_key = 'secret_for_realsies'


@app.route('/')
def index():
    return render_template('index.html')


@app.route('/cats')
def cats():
    return render_template('cats.html')


@app.route('/form')
def form_page():
    return render_template('form.html')

@app.route('/form', methods=['POST'])
def form_submit():
    session['name'] = request.form['name'] 
    session['email'] = request.form['email']
    return redirect('/')


app.run(debug=True)