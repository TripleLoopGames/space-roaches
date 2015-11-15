﻿using UnityEngine;
using System.Collections;
using System;

public class SpaceRoaches : MonoBehaviour
{
    private Camera _mainCamera;
    private GameObject _astronaut;

    private UserInput _userInput;
    private Smooth_Follow _smoothFollow;
    private EntitySpawner _entitySpawner;

    void Start()
    {
        this.InitializeCamera()
            .InitializeUserInput()
            .InitializeBackgorund()
            .InitializeForeGround()
            .InitializeAstronaut()
            .InitializeEntitySpawner()
            .SetReferences()
            .StartGame();
    }

    private SpaceRoaches StartGame()
    {
        _userInput.EnableInput();
        _entitySpawner.RandomSpawnRoaches(20);
        return this;
    }

    private SpaceRoaches InitializeCamera()
    {
        GameObject mainCamera = SRResources.Base.BaseCamera.Instantiate();
        mainCamera.name = "mainCamera";
        mainCamera.transform.parent = this.gameObject.transform;
        _mainCamera = mainCamera.GetComponent<Camera>();
        _smoothFollow = mainCamera.GetComponent<Smooth_Follow>();
        return this;
    }

    private SpaceRoaches InitializeUserInput()
    {
        GameObject userInput = SRResources.Base.UserInput.Instantiate();
        userInput.name = "userInput";
        userInput.transform.parent = this.gameObject.transform;
        _userInput = userInput.GetComponent<UserInput>();
        return this;
    }

    private SpaceRoaches InitializeBackgorund()
    {
        GameObject background = SRResources.Environment.background.Instantiate();
        background.name = "background";
        background.transform.parent = this.gameObject.transform;
        return this;
    }

    private SpaceRoaches InitializeForeGround()
    {
        GameObject gameWalls = SRResources.Environment.gameWalls.Instantiate();
        gameWalls.name = "gameWalls";
        gameWalls.transform.parent = this.gameObject.transform;
        return this;
    }

    private SpaceRoaches InitializeAstronaut()
    {
        GameObject astronaut = SRResources.Characters.Astronaut.Instantiate();
        astronaut.name = "Astronaut";
        astronaut.transform.parent = this.gameObject.transform;
        _astronaut = astronaut;
        return this;
    }

    private SpaceRoaches SetReferences()
    {
        _smoothFollow.SetCameraTarget(_astronaut);
        _userInput.SetCamera(_mainCamera);
        return this;
    }

    private SpaceRoaches InitializeEntitySpawner()
    {
        GameObject entitySpawner = SRResources.Base.EntitySpawner.Instantiate();
        entitySpawner.name = "entitySpawner";
        entitySpawner.transform.parent = this.gameObject.transform;
        _entitySpawner = entitySpawner.GetComponent<EntitySpawner>();
        _entitySpawner.InitializeSpawner();
        return this;
    }

}