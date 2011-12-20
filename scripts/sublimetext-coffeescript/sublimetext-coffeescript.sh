#!/bin/sh
PACKAGES_DIR=~/Library/Application\ Support/Sublime\ Text\ 2/Packages
COFFEE_PACKAGE_DIR=$PACKAGES_DIR/CoffeeScript
USER_PACKAGES_DIR=$PACKAGES_DIR/User

mkdir "$COFFEE_PACKAGE_DIR"
curl https://raw.github.com/jashkenas/coffee-script-tmbundle/master/Syntaxes/CoffeeScript.tmLanguage -o "$COFFEE_PACKAGE_DIR/CoffeeScript.tmLanguage"
curl https://raw.github.com/jashkenas/coffee-script-tmbundle/master/Preferences/CoffeeScript.tmPreferences -o "$COFFEE_PACKAGE_DIR/CoffeeScript.tmPreferences"

cp CoffeeScript.sublime-build "$USER_PACKAGES_DIR"
