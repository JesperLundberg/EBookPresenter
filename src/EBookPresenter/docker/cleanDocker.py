#!/usr/bin/python3

import subprocess
from dockerUtilities import get_value

def does_container_exist(container_name):
    command = ['docker', 'ps', \
    '--filter "name=' + container_name +'"', '-q']
    result = subprocess.run(command, stdout=subprocess.PIPE)

    if not result:
        return True
    else:
        return False

print(does_container_exist(get_value("name")))