from flask import Flask, render_template, url_for

app = Flask(__name__)

@app.route('/')
def index():
    opening_phrase = True
    return render_template('index.html', opening_phrase=opening_phrase)


@app.route('/all')
def all_img():
    display_all = True
    img_dict = {'red': "https://goo.gl/ZErms6",
                'black': "https://goo.gl/5CYrCU",
                'brown': "https://goo.gl/ahg5Fc"}
    return render_template('index.html', 
                           display_all=display_all,
                           img_dict=img_dict)


@app.route('/all/<color>')
def get_color(color):
    display_all = False
    return render_template('index.html', 
                           display_all=display_all,
                           color=color)


app.run(debug=True)