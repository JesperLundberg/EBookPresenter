#!/usr/bin/python3

import subprocess
import os

def get_value(filename):
    with open(filename) as f:
        content = f.readlines()
    return content[0].strip()

def container_exist(container_name):
    command = ['docker', 'ps', '--filter', 'name=' + container_name, '-q']
    result = subprocess.run(command, stdout=subprocess.PIPE)

    if not result.stdout:
        return False
    else:
        return True

def image_exist(image_name):
    command = ['docker', 'images', image_name, '-q']
    result = subprocess.run(command, stdout=subprocess.PIPE)

    if not result.stdout:
        return False
    else:
        return True

def remove_container(container_name):
	command = "docker stop " + container_name
	result = os.system(command)

	# If container stopped successfully, remove it
	if result == 0:
		command = "docker rm -f " + container_name
		result = os.system(command)

	return result