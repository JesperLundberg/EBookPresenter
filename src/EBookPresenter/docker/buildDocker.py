#!/usr/bin/python3

import os
import subprocess
import dockerUtilities

def create_folder(path_to_create):
    os.makedirs(path_to_create)

def folder_exists(path):
    if os.path.exists(path):
        return True
    else:
        return False

def clean_build_folder(path):
	command = "rm -rf " + path
	os.system(command)

def copy_source_code():
    print("Copying source code")
    command = ['rsync', '-av', '../','./build', 
    '-exclude bin', '-exclude obj']
    result = subprocess.run(command, stdout=subprocess.PIPE)
    return result.stdout

def build_docker():
    print("Building docker file")
    command = "docker build -t " + dockerUtilities.get_value("name") + ":" +\
    dockerUtilities.get_value("release") + " build/"
    os.system(command)

# Actual script

if not folder_exists("build/"):
    create_folder("build/")
else:
	# Clean folder to make sure there are no left overs
	clean_build_folder("build/")
	create_folder("build/")

copy_source_code()

build_docker()