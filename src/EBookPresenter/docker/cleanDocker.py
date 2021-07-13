#!/usr/bin/python3

import subprocess
import os
from dockerUtilities import get_value
from dockerUtilities import image_exist
from dockerUtilities import container_exist


def remove_container(container_name):
	command = "docker stop " + container_name
	result = os.system(command)

	if result == 0:
		command = "docker rm -f " + container_name
		result = os.system(command)

	return result

def remove_image(image_name):
	command = "docker rmi " + image_name
	result = os.system(command)

	return result

if(container_exist(get_value("name"))):
	remove_container(get_value("name"))

if(image_exist(get_value("name") + ":" + get_value("release"))):
	remove_image(get_value("name") + ":" + get_value("release"))