@echo off
@git add -A
@timeout 5
@git commit -m "updates"
@timeout 15
@git push