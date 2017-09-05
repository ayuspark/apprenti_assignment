import requests

r = requests.get('http://pokeapi.co/api/v1/pokemon/1/')
print r.json()['abilities'][0]['name']