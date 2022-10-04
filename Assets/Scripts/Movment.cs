using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour
{
    [SerializeField] float mainThrust = 1f;
    [SerializeField] float rotationThrust = 1f;
    [SerializeField] AudioClip mainEngine;

    [SerializeField] ParticleSystem mainEngineParticle;
    [SerializeField] ParticleSystem leftThrusterParticle;
    [SerializeField] ParticleSystem rightThrusterParticle;

    [SerializeField] GameObject tavan;

    Rigidbody rb;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();

        TavanKaldır();
    }

    void TavanKaldır()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            tavan.GetComponent<Test>().Dell();
        }
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            ApplyThrusting();
        }

        else
        {
            StopThrusting();
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }

        else if (Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
        else
        {
            StopRotating();
        }
    }

    void ApplyThrusting()
    {
        rb.AddRelativeForce(mainThrust * Time.deltaTime * Vector3.up);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }
        if (!mainEngineParticle.isPlaying)
        {
            mainEngineParticle.Play();
        }
    }

    void StopThrusting()
    {
        audioSource.Stop();
        mainEngineParticle.Stop();
    }

    void RotateLeft()
    {
        ApplyRotation(rotationThrust);
        if (!rightThrusterParticle.isPlaying)
        {
            rightThrusterParticle.Play();
        }
    }

    void RotateRight()
    {
        ApplyRotation(-rotationThrust);
        if (!leftThrusterParticle.isPlaying)
        {
            leftThrusterParticle.Play();
        }
    }
    void StopRotating()
    {
        rightThrusterParticle.Stop();
        leftThrusterParticle.Stop();
    }

    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(rotationThisFrame * Time.deltaTime * Vector3.forward);
        rb.freezeRotation = false;
    }
}

