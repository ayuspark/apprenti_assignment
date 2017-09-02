from flask import Flask


app = Flask(__projects__)


@app.route('/projects')
def intro():

    return '''<ul>
                <li>BusMall</li>
                <li>Salmon Cookie</li>
                <li>FuzzFeed</li>
                <li>Pacman</li>          
            </ul>'''

app.run(debug=True)