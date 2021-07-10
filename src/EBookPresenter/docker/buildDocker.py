#!/usr/bin/python3

import os
import subprocess

def create_folder(path_to_create):
    os.makedirs(path_to_create)

def folder_exists(path):
    if os.path.exists(path):
        return True
    else:
        return False

def copy_source_code():
    print("Copying source code")
    command = ['rsync', '-av', '../','./build']
    result = subprocess.run(command, stdout=subprocess.PIPE)
    return result.stdout

# Actual script

if not folder_exists("build/"):
    create_folder("build/")

copy_source_code()