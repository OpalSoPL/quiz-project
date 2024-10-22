# Quiz-Project

Game created as part of a school project.

Developed using godot 4.4-dev3 (mono), but should also work with Godot 4.3 (mono)

## Mini Documentation

### `appSettings.json`

##### Version

Default: `1`

Determines version of JSON file schema.

##### Question_file

Path to the file containing questions.

##### Run_from_question

Default: `-1`

Number of the question that is shown after startup.

values:
- `-1` - Shows main menu.
- `0 =< x` - Shows questions starting from `x`, Skipping main menu.

##### Debug
Not implemented.

#### Example:
```json
{
    "Version": 1,
    "Question_file": "/home/someUser/questions.json",
    "Run_from_question": -1,
    "Debug": false
}
```

### Question files

##### Version

default: `1`

Determines the version of JSON file schema.

##### Data

Array of questions.

- ***Description***

Question description.

- ***CorrectAnswer***

Value in the range `0` - `3`

Points to the correct answer.

**example**:

```json
[...]
    "0": {
        [...]
        "CorrectAnswer": 2,
        "Answers": {
                "A": "Something A",
                "B": "Something B",
                "C": "Something C", //<-- correct Answer
                "D": "Something D"
            }
    }
[...]
```
- ***Answers***

value in the range: `A` - `D`.

list of texts for each answer button.

The number of questions can vary.


### File Structure Example
```json
{
    "Version": 1,
    "Data": {
        "0": {
            "Description": "What is 100*50/2 ?",
            "CorrectAnswer": 0,
            "Answers": {
                "A": "2500",
                "B": "1000",
                "C": "5000",
                "D": "2137"
            }
        },
        "1": {
            "Description": "What is the largest planet in the Solar System?",
            "CorrectAnswer": 2,
            "Answers": {
                "A": "Earth",
                "B": "Venus",
                "C": "Jupiter"
            }
        }
    }
}
```

## License

The Project is shared under the MIT license
see the [LICENSE file](LICENSE).