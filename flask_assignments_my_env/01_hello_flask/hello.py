from flask import Flask, render_template
from flask_bootstrap import Bootstrap

app = Flask(__name__)
bootstrap = Bootstrap(app)

@app.route('/')
def hello_py():
    return '<h1>Hello Flask????</h1><p>What the f is this shit. Coding Dojo simplifies the course content to kindergarten level and students think they can actually code.</p>'

app.run(debug=True)
