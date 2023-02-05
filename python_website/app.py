from flask import Flask, render_template,request
 
import pyodbc 
import pandas as pd
import matplotlib.pyplot as plt
import numpy as np
from geopy.geocoders import Nominatim
import requests
import json
import googlemaps

app = Flask(__name__)
city = 'Gliwice'
WEATHER_API_KEY = 'f1503489d48443798f2d6ccdddbacde0'

@app.route('/')
def google_pie_chart():
    cnxn = pyodbc.connect("Driver={SQL Server Native Client 11.0};"
                      "Server=sql.bsite.net\\MSSQL2016;"
                      "Database=krulicusek_HomeWorkout;"
                      "UID=krulicusek_HomeWorkout;"
                      "PWD=HomeWorkout123;"
                      "Trusted_Connection=no;")

    query = ('SELECT u.FirstName, u.LastName,hm.NumberOfTimes,hm.Seconds,hm.PlaceInSequence,(hm.NumberOfTimes*hm.Seconds) as TotalTime,hm.PlaceInSequence, ex.Name FROM [krulicusek_HomeWorkout].[dbo].[Users] as u '
    +'JOIN [krulicusek_HomeWorkout].[dbo].[HomeworkSequenceModel] as hsm on u.Id = hsm.UserId '
    +'JOIN [krulicusek_HomeWorkout].[dbo].[HomeworkModel] as hm on hsm.Id = hm.HomeworkSequenceModelId '
    +'JOIN [krulicusek_HomeWorkout].[dbo].[ExerciseModel] as ex on ex.Id = hm.ExerciseModelId '
    +'where u.Id =1;')

    data = pd.read_sql(query,cnxn)
    data['Index'] = data.sort_index
    data['Name'] = data['Name'].astype(pd.StringDtype())
    chart_data = data[["Index","Name","TotalTime"]]
    
    chart_data = chart_data.set_index('Index').to_json(orient='records')
    return render_template('index.html', chart_data=chart_data)
 
@app.route("/weather",methods = ['GET','POST'])
def weather():
    city = request.args.get('user-text')
    if city == '':
        city = 'Gliwice'
    weather_data = requests.get(
        f"https://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&APPID={WEATHER_API_KEY}")

    if weather_data.json()['cod'] == '404':
        print("No City Found")
    else:

        weather_info = {
            'city' : city,
            'weather' : weather_data.json()['weather'][0]['main'],
            'lon' : weather_data.json()['coord']['lon'],
            'lat' : weather_data.json()['coord']['lat'],
            'temperature' : weather_data.json()['main']['temp'],
            'icon' : weather_data.json()['weather'][0]['icon']
        }
        return(json.dumps(weather_info))

@app.route('/<id>')
def user_profile(id):
    cnxn = pyodbc.connect("Driver={SQL Server Native Client 11.0};"
                      "Server=sql.bsite.net\\MSSQL2016;"
                      "Database=krulicusek_HomeWorkout;"
                      "UID=krulicusek_HomeWorkout;"
                      "PWD=HomeWorkout123;"
                      "Trusted_Connection=no;")

    query = ('SELECT u.FirstName, u.LastName,hm.NumberOfTimes,hm.Seconds,hm.PlaceInSequence,(hm.NumberOfTimes*hm.Seconds) as TotalTime,hm.PlaceInSequence, ex.Name FROM [krulicusek_HomeWorkout].[dbo].[Users] as u '
    +'JOIN [krulicusek_HomeWorkout].[dbo].[HomeworkSequenceModel] as hsm on u.Id = hsm.UserId '
    +'JOIN [krulicusek_HomeWorkout].[dbo].[HomeworkModel] as hm on hsm.Id = hm.HomeworkSequenceModelId '
    +'JOIN [krulicusek_HomeWorkout].[dbo].[ExerciseModel] as ex on ex.Id = hm.ExerciseModelId '
    +'where u.Id ='+ id + ';')

    data = pd.read_sql(query,cnxn)
    data['Index'] = data.sort_index
    data['Name'] = data['Name'].astype(pd.StringDtype())
    chart_data = data[["Index","Name","TotalTime"]]
    
    chart_data = chart_data.set_index('Index').to_json(orient='records')
    return render_template('page.html', chart_data=chart_data)

if __name__ == "__main__":
    app.run()