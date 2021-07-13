#!/usr/bin/python3

import subprocess

def get_value(filename):
    with open(filename) as f:
        content = f.readlines()
    return content[0]

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