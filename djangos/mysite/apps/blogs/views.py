# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.shortcuts import render
from django.http import HttpResponse

# Create your views here.
def index(request):
    return HttpResponse('You are in blogs!')


def new_blog(request):
    return HttpResponse('New blog here!')


def show(request, blog_id):
    print(blog_id)
    return HttpResponse('Show %s blogs!' % (blog_id))


def edit(request, blog_id):
    return HttpResponse('Edit blogs here! Blog ID is: %s' % (blog_id))


