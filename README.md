# Social Network Project

A social networking platform designed for student communication worldwide, developed as a Data Structures course project.

## Team
- [MohammadSaleh Mahdinejad](https://github.com/msmahdinejad)
- [Arash Zarghami](https://github.com/ArashZrg)
- University of Isfahan, Computer Engineering Faculty
- Winter 2024

## Features

### User Management
- User registration and login with unique username and password
- Personal profile pages with user information and posts
- Profile visibility limited to user and their followers
- Follow/unfollow functionality between users
- Edit/delete personal information and posts
- Complete account deletion option

### Smart Connection System
- Intelligent friend suggestion algorithm
- Recommends 6 potential connections based on mutual followers
- Uses similarity ratio: (mutual followers) / (total unique followers)
- Fallback to newest users when no mutual connections exist
- Probability score between 0-1 for connection likelihood

## Technical Requirements
- Clean, well-documented code
- Git version control mandatory
- Optional GUI implementation for bonus points

## Algorithm Details

The friend suggestion system calculates connection probability using:
```
Similarity = Number of Mutual Followers / Total Unique Followers of Both Users
```

This generates a score between 0 and 1, where higher values indicate stronger potential connections.

## Project Structure
The implementation includes:
- User authentication system
- Profile management
- Social networking features
- Intelligent recommendation engine
- Data structure optimization for performance

## Contributing
This project was developed as an academic assignment focusing on data structures and algorithms in social network contexts.
