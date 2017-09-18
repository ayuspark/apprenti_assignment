from django.conf.urls import url
from . import views

urlpatterns = [
        url(r'^$', views.index, name='index'),
        url(r'^new$', views.new_blog, name='new_blog'),
        url(r'^(?P<blog_id>\d+)$', views.show),
        url(r'^edit/(?P<blog_id>[0-9]{4})/$', views.edit),
]
