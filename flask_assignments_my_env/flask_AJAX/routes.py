from flask import Flask, render_template, request, url_for

app = Flask(__name__)

@app.route('/')
def index():
    return render_template('index.html')

@app.route('/', methods=['GET','POST'])
def show_img():
    if request.method == "POST":
        data = json.loads(request.form.get('data'))
        response = data['color']
        # response = request.args
        print(response)
        return render_template('index.html', response=response)
    # if you are in Chrome and look at Network, click on the latest ajax call(on localhost), you can see the {'color': color} is passed, and it is under header Form Data
    # but somehow, I used get_json(), request.data, etc and nothing works. 

app.run(debug=True)
