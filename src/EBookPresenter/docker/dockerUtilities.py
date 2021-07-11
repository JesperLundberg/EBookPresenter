#!/usr/bin/python3

def get_value(filename):
    with open(filename) as f:
        content = f.readlines()
    return content[0]