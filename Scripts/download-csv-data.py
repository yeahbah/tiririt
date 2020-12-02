import requests
import datetime
import os
import sys

year = sys.argv[1]
outputDir = sys.argv[2]
baseUrl = 'http://shared4.info/psequotes/files/' + year +'/'
startDate = datetime.datetime(int(year), 1, 1);
currentDate = datetime.datetime.today()
# print(currentDate.date())
while startDate.date() != currentDate.date():
    startDate = startDate + datetime.timedelta(days=1)
    fileName = 'stockQuotes_' + startDate.strftime("%m%d%Y") + '.csv'
    print('downloading ' + fileName +'...')
    url = baseUrl + fileName
    r = requests.get(url, allow_redirects=True)    
    if (r.status_code == 200):    	
        output = os.path.join(outputDir, fileName)
        open(output, 'wb').write(r.content)
    else:
    	print('not found.')
