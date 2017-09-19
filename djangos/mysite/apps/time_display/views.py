# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.shortcuts import render, redirect
from django.http import HttpResponse
from time import gmtime, strftime
from django.utils.crypto import get_random_string


# Create your views here.
def index(request):
    context = {
        'time': strftime('%Y-%m-%d %H:%M %p', gmtime())
    }
    return render(request, 'time_display/index.html', context)


def rand_str(request):
    if 'str_count' not in request.session:
        request.session['str_count'] = 0
    else:
        request.session['str_count'] += 1
    context = {
        'rand_str': get_random_string(length=14),
        'str_count': request.session['str_count'],
    }
    return render(request, 'time_display/rand_str.html', context)


def session_words(request):
    if 'words' not in request.session:
        request.session['words'] = []

    return render(request, 'time_display/session_words.html')


def add_word(request):
    if request.method == 'POST':
        word = request.POST['add_word']
        time = strftime('%Y-%m-%d %H:%M %p', gmtime())
        color = request.POST['color']
        font_size = request.POST.get('font_size', False)

        request.session['words'].append({
            'time': time,
            'word': word,
            'color': color,
            'font_size': font_size,
        })
        request.session.modified = True
        print(request.session['words'])

        return redirect('/time_display/session_words')


def clear(request):
    request.session.pop('words')
    return redirect('/time_display/session_words')
