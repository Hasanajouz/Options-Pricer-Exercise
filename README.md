# Options Pricer Exercise
An Exercise for digistrat consulting

This is a small WPF application capable of calculating the price of European call or put options using the Black-Scholes pricing model.  

# Why WPF
I decided to use WPF so I can use MVVM to show my architecture ability. If I use windows forms then I would have used the old method of the three layers:Data Access, Business Layer and View Layer.

# MVVM Architecture in this project
As this is a small app I should have used models and views and viewmodels insde the same project.
But, I decided to add them in seperate projects because I was asked to use the same standerds I used to write my code with.
When you develop big projects then a small folder to handle models or view models will not be a good practice, specially if you are going to reuse this code in other projects.
![alt text](https://raw.githubusercontent.com/hasanajouz/Options-Pricer-Exercise/master/Images/projects.jpg)

