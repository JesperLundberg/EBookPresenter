#!/usr/bin/python3

import os
from dockerUtilities import get_value
from dockerUtilities import container_exist
from dockerUtilities import remove_container

def run_docker(container_name, release, path_to_bind):
    command = "docker run -d -p 5000:80 --mount type=bind,source=" +\
    path_to_bind +\
    ",target=/books,readonly --name " + container_name + " " +\
    container_name + ":" + release
    result = os.system(command)

    return result

if(container_exist(get_value("name"))):
    remove_container(get_value("name"))

run_docker(get_value("name"), get_value("release"), "/mnt/c/temp/")