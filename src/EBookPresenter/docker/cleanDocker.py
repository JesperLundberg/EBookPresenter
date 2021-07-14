#!/usr/bin/python3

import subprocess
import os
from dockerUtilities import get_value
from dockerUtilities import image_exist
from dockerUtilities import container_exist
from dockerUtilities import remove_container

def remove_image(image_name):
	command = "docker rmi " + image_name
	result = os.system(command)

	return result

if(container_exist(get_value("name"))):
	remove_container(get_value("name"))

if(image_exist(get_value("name") + ":" + get_value("release"))):
	remove_image(get_value("name") + ":" + get_value("release"))