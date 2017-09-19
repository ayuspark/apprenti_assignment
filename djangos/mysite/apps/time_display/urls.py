from django.conf.urls import url
from . import views

urlpatterns = [
        url(r'^$', views.index, name='index'),
        url(r'^rand_str$', views.rand_str),
        url(r'^session_words$', views.session_words),
        url(r'^session_words/add_word$', views.add_word),
        url(r'^session_words/clear$', views.clear),
    ]
