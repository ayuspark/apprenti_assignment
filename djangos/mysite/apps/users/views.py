# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.shortcuts import render, HttpResponse

# Create your views here.
def index(response):
    return HttpResponse('You are at users!')


def new_user(response):
    return HttpResponse('You are at create users')


def show(response, user_id):
    return HttpResponse('Show user, ID is %s' % (user_id))


def edit(response, user_id):
    return HttpResponse('Edit user, ID is %s' % (user_id))