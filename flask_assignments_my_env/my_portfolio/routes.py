from flask import Flask, render_template


app = Flask(__name__)


@app.route('/')
def intro():
    return render_template('index.html')


@app.route('/about')
def about():
    return render_template('about_me.html')


@app.route('/projects')
def projects():
    my_projects = ['fuzzfeed', 'busmall', 'salmon cookie']
    return render_template('projects.html', projects=my_projects)

app.run(debug=True)