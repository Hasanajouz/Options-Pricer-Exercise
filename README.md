# Options Pricer Exercise
An Exercise for digistrat consulting

Here is a small documentaion covering the steps I made to finish this exersice.

This is a basic WPF application capable of calculating the price of European call or put options using the Black-Scholes pricing model.  

# Why WPF
I decided to use WPF so I can use MVVM to show my architecture strenght. If I use windows forms then I would have used the old method of the three layers:Data Access, Business Layer and View Layer.

# MVVM Architecture in this project
As this is a small app I should have used models and views and viewmodels insde the same project.
But, I decided to add them in seperate projects because I was asked to use the same standerds I used to write my code with.
When you develop big projects then a small folder to handle models or view models will not be a good practice, specially if you are going to reuse this code in other projects.

![alt text](https://raw.githubusercontent.com/hasanajouz/Options-Pricer-Exercise/master/Images/projects.jpg)

# Model
In this app there will be only one model to handel everything I called it: BlacksCholes

![alt text](https://raw.githubusercontent.com/hasanajouz/Options-Pricer-Exercise/master/Images/model.jpg)

# Calculations
all the calculations will be in the helper projects.
there will be two files
1- BlacksCholesCalculator.cs to caclculate the pricing using Blacks Choles way.
2-NormalDistributionHelper to calculate the normal distipution because it is used in one of the fourmulas of calculating the call price.
I tried more than one methode to calculate Normal Distribution because i was searching for one which gives the more accurate result.
I found one in the internet that passed all my tests to give exact the same results as the suggested website.

# Unit Testing
As it is a small app I made unit testing with ms unit testing.
It is just simple values check.
And i tried to cover all fields and methods with my tests

![alt text](https://raw.githubusercontent.com/hasanajouz/Options-Pricer-Exercise/master/Images/unitTest.jpg)

![alt text](https://raw.githubusercontent.com/hasanajouz/Options-Pricer-Exercise/master/Images/function_tested.jpg)

# View Model
After all the tests went well. I started to implement the UI.
So, i started with the view model.
I created the base view model which all the view models will inhirit from.
It handels all common properties and specially the "PropertyChangedEventHandler"
and I created a basic class to inhirit from ICommand to handel commands. it is called  "DelegateCommand"

# UI and Binding
After I created the view main page.
And I tried to show small example about local styles.
![alt text](https://raw.githubusercontent.com/hasanajouz/Options-Pricer-Exercise/master/Images/function_tested.jpg)

![alt text](https://raw.githubusercontent.com/hasanajouz/Options-Pricer-Exercise/master/Images/function_tested.jpg)


 




