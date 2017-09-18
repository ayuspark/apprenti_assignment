# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.shortcuts import render
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
    print(request.session['str_count'])
    return render(request, 'time_display/rand_str.html', context)
