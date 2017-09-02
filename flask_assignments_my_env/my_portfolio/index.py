from flask import Flask


app = Flask(__name__)


@app.route('/')
def intro():

    return '<h1>Lola</h1>'

app.run(debug=True)