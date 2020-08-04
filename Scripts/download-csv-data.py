import requests
import datetime


baseUrl = 'http://shared4.info/psequotes/files/2020/'
startDate = datetime.datetime(2020, 1, 1);
currentDate = datetime.datetime.today()
# print(currentDate.date())
while startDate.date() != currentDate.date():
    startDate = startDate + datetime.timedelta(days=1)
    fileName = 'stockQuotes_' + startDate.strftime("%m%d%Y") + '.csv'
    print('downloading ' + fileName +'...')
    url = baseUrl + fileName
    r = requests.get(url, allow_redirects=True)
    if (r.status_code == 200):
        open(fileName, 'wb').write(r.content)