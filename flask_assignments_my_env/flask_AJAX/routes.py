from flask import Flask, render_template, request, url_for, json, jsonify, redirect

app = Flask(__name__)
app.secret_key = '123456'

@app.route('/')
def index():
    return render_template('index.html')

@app.route('/', methods=['POST'])
def get_img_id():
    if request.method == "POST":
        data_posted = json.loads(request.data)['color']
        response = json.dumps(data_posted)
        print(response)
        # return response
        return response
    
app.run(debug=True)
