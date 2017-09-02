from flask import Flask


app = Flask(__'about_me'__)


@app.route('/about')
def about_me():

    return '<p>I love Code Fellows so much. They care about education and we learn well-structured knowledge every day!</p>'

app.run(debug=True)