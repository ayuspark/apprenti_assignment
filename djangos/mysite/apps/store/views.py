# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.shortcuts import render, redirect


# Create your views here.
def index(request):
    context = {'store': [
        {'name': 'Cup', 'price': 20},
        {'name': 'Mug', 'price': 19},
        {'name': 'Glass', 'price': 18},
        {'name': 'iPhone', 'price': 1000}]
    }
    return render(request, 'store/index.html', context)


def process(request):
    if 'item_price' not in request.session:
        request.session['items_price'] = 0
    if request.method == 'POST':
        item_price = int(request.POST.get('items', 0))
        item_quantity = int(request.POST.get('quantity', 0))
        single_transaction_price = item_quantity * item_price 

        request.session['total_quantity'] += item_quantity
        request.session['items_price'] = single_transaction_price
        request.session['total_price'] += single_transaction_price
        request.session.modified = True
    return redirect('/store/checkout')


def checkout(request):
    return render(request, 'store/checkout.html', context=None)