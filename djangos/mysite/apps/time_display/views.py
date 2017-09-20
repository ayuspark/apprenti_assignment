# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from time import strftime, localtime, gmtime
from django.shortcuts import render, redirect
from django.utils.crypto import get_random_string

from .models import *


# Create your views here.
def index(request):
    # display time view
    context = {
        'time': strftime('%Y-%m-%d %H:%M %p', localtime())
    }
    return render(request, 'time_display/index.html', context)


def rand_str(request):
    # rand_str view
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
    # index page for session_words
    if 'words' not in request.session:
        request.session['words'] = []

    return render(request, 'time_display/session_words.html')


def add_word(request):
    # add words to session_words
    if request.method == 'POST':
        word = request.POST['add_word']
        time = strftime('%Y-%m-%d %H:%M %p', localtime())
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
    # clear session['words']
    request.session.pop('words')
    return redirect('/time_display/session_words')


def school_student(request):
    context = {
        'all_students': Student.objects.all(),
        'all_schools': School.objects.all(),
    }
    return render(request, 'time_display/index.html', context)
