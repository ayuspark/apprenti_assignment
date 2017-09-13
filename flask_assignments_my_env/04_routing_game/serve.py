from flask import Flask, render_template

app = Flask(__name__)

@app.route('/')
def index():
    return render_template('index.html')

@app.route('/left')
def left():
    return render_template('left.html')

@app.route('/right')
def right():
    return render_template('right.html')


@app.route('/red')
def red():
    return render_template('red.html')


@app.route('/black')
def black():
    return render_template('black.html')

app.run(debug=True)
