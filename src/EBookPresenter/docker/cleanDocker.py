#!/usr/bin/python3

import subprocess
import os
from dockerUtilities import get_value

def does_container_exist(container_name):
	command = ['docker', 'ps', '--filter', 'name=' + container_name, '-q']
	result = subprocess.run(command, stdout=subprocess.PIPE)
	
	if not result.stdout:
		return False
	else:
		return True

def does_image_exist(image_name):
	command = ['docker', 'images', image_name, '-q']
	result = subprocess.run(command, stdout=subprocess.PIPE)

	if not result.stdout:
		return False
	else:
		return True

def remove_container(container_name):
	command = "docker stop " + container_name
	result = os.system(command)

	if result == 0:
		command = "docker rm -f " + container_name
		result = os.system(command)

	return result

print(does_container_exist(get_value("name")))
print(does_image_exist(get_value("name") + ":" + get_value("release")))

#print(remove_container(get_value("name")))