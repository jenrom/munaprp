$status = git status

if ($status[0].endswith("master"))
{
  "You need to run this on a non master branch"
  exit
}

git add -A
git commit -m "Pushing new changes"
git push origin

