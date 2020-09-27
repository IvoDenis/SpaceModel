function [ Y ] = Earth(t, X )
%UNTITLED2 Summary of this function goes here
%   Detailed explanation goes here
mu=132712440018;
r= sqrt(X(1)^2+X(2)^2+X(3)^2);
Y=[X(4);X(5);X(6);-mu*X(1)/r^3;-mu*X(2)/r^3;-mu*X(3)/r^3];

end

