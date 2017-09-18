from django.conf.urls import url
from . import views

urlpatterns = [
    url(r'^$', views.index, name='index'),
    url(r'^new$', views.new_user, name='new_blog'),
    url(r'^(?P<user_id>[0-9]{2})$', views.show),
    url(r'^edit/(?P<user_id>[0-9]{2})$', views.edit),
]
