#!/bin/sh

# Takes clipboard contents, runs markdown, and then directs Safari to open the generated HTML
# Requires Markdown.pl to be in the path


TMPFILE=`mktemp -t markdown`.html || exit 1
pbpaste | Markdown.pl > $TMPFILE
open $TMPFILE
