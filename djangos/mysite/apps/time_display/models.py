# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.db import models

# Create your models here.
class School(models.Model):
    name = models.CharField(max_length=20)
    city = models.CharField(max_length=20)
    state = models.CharField(max_length=2)


class Student(models.Model):
    fname = models.CharField(max_length=10)
    lname = models.CharField(max_length=10)
    school = models.ForeignKey(School, related_name='in_school_students')
